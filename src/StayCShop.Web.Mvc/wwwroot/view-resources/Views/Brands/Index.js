(function ($) {

    l = abp.localization.getSource('StayCShop');
    var _mService = abp.services.app.brand;
    var _$table = $('#DataTable');

    _$modal = $('#CreateOrEditModal');
    _$form = _$modal.find('form');

    _$modalEdit = $('#EditModal');
    _$formEdit = _$modal.find('form');

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
                action: () => dataTable.draw(false)
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
                data: 'brandName',
                sortable: false,
            },
            {
                targets: 2,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-primary edit-info" data-info-id="${row.id}" data-toggle="modal" data-target="#EditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-info" data-info-id="${row.id}" data-info-name="${row.brandName}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });

    //_$form.validate({
    //    rules: {
    //        Password: "required",
    //        ConfirmPassword: {
    //            equalTo: "#Password"
    //        }
    //    }
    //});

    function Save(_$formObj, _$modalObj) {
        _$formObj.find('.save-button').on('click', (e) => {
            e.preventDefault();

            if (!_$formObj.valid()) {
                return;
            }

            var info = _$form.serializeFormToObject();

            abp.ui.setBusy(_$modalObj);
            _mService.createOrUpdate(info).done(function () {
                _$modalObj.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                getData();
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
        abp.ajax({
            url: abp.appPath + 'Brands/CreateOrEditBrandModal?Id=' + objId,
            type: 'Get',
            dataType: 'html',
            success: function (content) {
                console.log(content);
                $('#EditModal div.modal-content').html(content);
                //$('.modal fade').tab('show')
                //$('.nav-tabs a[href="#info-details"]').tab('show');
            },
            error: function (e) {
                console.log(e);
            }
        });
    });

    $(document).on('click', 'a[data-target="#CreateOrEditModal"]', (e) => {
        //$('.nav-tabs a[href="#info-details"]').tab('show')
        $('.modal fade').tab('show')
    });

    abp.event.on('Brand.edited', (data) => {
        getData();
    });

    //_$modalEdit.on('shown.bs.modal', () => {
    //    _$modalEdit.find('input:not([type=hidden]):first').focus();
    //}).on('hidden.bs.modal', () => {
    //    _$form.clearForm();
    //});

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
    }
})(jQuery);


