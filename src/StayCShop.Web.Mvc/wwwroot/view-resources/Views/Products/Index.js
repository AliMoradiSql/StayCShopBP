﻿(function ($) {

    l = abp.localization.getSource('StayCShop');
    var _mService = abp.services.app.product;
    var _$table = $('#DataTable');

    _$modal = $('#CreateOrEditModal');
    _$form = _$modal.find('form');

    _$modalEdit = $('#EditModal');
    _$formEdit = _$modal.find('form');

    var rowCount = 1;
    var dataTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _mService.getAll,
            inputFilter: function () {
                return {
                    filter: $('#TableFilter').val()
                };
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: function () {
                    dataTable.draw(false);
                    rowCount = 1;
                }
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                render: function () {
                    return rowCount++;
                },
                sortable: false,
            },
            {
                targets: 2,
                data: 'name',
                sortable: false,
            },
            {
                targets: 3,
                data: 'price',
                sortable: false,
            },
            {
                targets: 4,
                data: 'color',
                sortable: false,
            },
            {
                targets: 5,
                data: 'size',
                sortable: false,
            },
            {
                targets: 6,
                data: 'material',
                sortable: false,
            },
            {
                targets: 7,
                data: 'quantity',
                sortable: false,
            },
            {
                targets: 8,
                data: 'brandName',
                sortable: false,
            },
            {
                targets: 9,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-primary edit-info" data-info-id="${row.id}" data-toggle="modal" data-target="#EditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-info" data-info-id="${row.id}" data-info-name="${row.productName}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });

    $('#textFile').change(function (event) {

        var files = event.target.files;

        $('#imageViewr').attr("src", window.URL.createObjectURL(files[0]));

    });

    function Save(_$formObj, _$modalObj) {
        _$formObj.find('.save-button').on('click', (e) => {
            e.preventDefault();

            if (!_$formObj.valid()) {
                return;
            }

            var files = $('#textFile')[0].files;
            var fd = new FormData();
            if (files.length > 0)
                fd.append('file', files[0]);

            var info = _$form.serializeFormToObject();
           

            abp.ui.setBusy(_$modalObj);
            abp.ajax({
                url: '/api/services/app/image/ConvertIamgeToByte',
                type: 'post',
                processData: false,
                contentType: false,
                data: fd
            }).done(function (data) {
                info.CoverImage = data;
                _mService.createOrUpdate(info).done(function () {
                    _$modalObj.modal('hide');
                    _$form[0].reset();
                    abp.notify.info(l('SavedSuccessfully'));
                    getData();
                });
            }).always(function () {
                abp.ui.clearBusy(_$modalObj);
            });
        });
    }
    Save(_$form, _$modal);

    $(document).on('click', '.delete-info', function () {
        var objId = $(this).attr("data-info-id");
        var objName = $(this).attr('data-info-name');

        deleteObj(objId, objName);
    });

    function deleteObj(objId, objName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                objName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _mService.delete({
                        id: objId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        getData();
                    });
                }
            }
        );
    }

    $(document).on('click', '.edit-info', function (e) {
        var objId = $(this).attr("data-info-id");

        e.preventDefault();
        location.href = '/Products/Detail?id=' + objId;
        //abp.ajax({
        //    url: abp.appPath + 'Products/CreateOrEditProductModal?Id=' + objId,
        //    type: 'Get',
        //    dataType: 'html',
        //    success: function (content) {
        //        $('#EditModal div.modal-content').html(content);
        //    },
        //    error: function (e) {
        //    }
        //});
    });

    $(document).on('click', 'a[data-target="#CreateOrEditModal"]', (e) => {
        $('.modal fade').tab('show')
    });

    abp.event.on('Product.edited', (data) => {
        getData();
    });


    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });



    $('.btn-search').on('click', (e) => {
        getData();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            getData();
            return false;
        }
    });

    function getData() {
        dataTable.ajax.reload();
        rowCount = 1;
    }

    $('#BrandId').select2({
        placeholder: l('SelectYourBrandName'),
        allowClear: true,
/*        theme: 'default',*/
        selectionCssClass: 'form-select',
        dropdownParent: _$modal,
        ajax: {
            url: abp.appPath + "api/services/app/Brand/GetAll",
            dataType: 'json',
            delay: 250,
            data: function (params) {

                return {
                    //searchTerm: params.term, // search term
                    //page: params.page,
                    filter: params.term, // search term
                    skipCount: params.page,
                    maxResultCount: 20
                };
            },
            processResults: function (data, params) {
                params.page = params.page || 1;

                return {
                    results: $.map(data.result.items, function (item) {
                        return {                            
                            text: item.brandName,
                            id: item.id
                        }
                    }),
                    pagination: {
                        more: (params.page * 10) <= data.result.totalCount
                    }
                };
            },
            cache: true
        },
        escapeMarkup: function (markup) {
            return markup;
        },
        minimumInputLength: 1,
/*        language: abp.localization.currentCulture.name,*/
        width: '100%'
    });
})(jQuery);


