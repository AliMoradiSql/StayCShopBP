(function ($) {

    l = abp.localization.getSource('StayCShop');
    var _mService = abp.services.app.image;
    var _$table = $('#DataTable');
    var _$productId = _$table.data('productId');

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
                    filter: $('#TableFilter').val(),
                    productId: _$productId
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
                data: 'title',
                sortable: false,
            },
            {
                targets: 3,
                data: 'image',
                sortable: false,
                render: function (img) {
                    var image = new Image();
                    image.src = 'data:image/png;base64,' + img;
                    if (img) {
                        var $container = $('<span/>');
                        var $link = $('<a/>').attr('href', image.src).attr('target','_blank');
                        var $img = $('<img/>').addClass('img-thumbnail').attr('src', image.src).attr('width', 70).attr('height', 70);

                        $link.append($img);
                        $container.append($link);

                        return $container[0].outerHTML;
                    }

                }
            },
            {
                targets: 4,
                data: 'description',
                sortable: false,
            },
            {
                targets: 5,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-primary edit-info" data-info-id="${row.id}" data-toggle="modal" data-target="#EditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-info" data-info-id="${row.id}" data-info-name="${row.title}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });

    $('#ImageInput').change(function (event) {

        var files = event.target.files;

        $('#imageViewr').attr("src", window.URL.createObjectURL(files[0]));

    });

    function Save(_$formObj, _$modalObj) {
        _$formObj.find('.save-button').on('click', (e) => {
            e.preventDefault();

            if (!_$formObj.valid()) {
                return;
            }

            var files = $('#ImageInput')[0].files;
            var fd = new FormData();
            if (files.length > 0)
                fd.append('file', files[0]);

            var info = _$form.serializeFormToObject();


            abp.ui.setBusy(_$modalObj);
            abp.ajax({
                url: '/api/services/app/Image/ConvertIamgeToByte',
                type: 'post',
                processData: false,
                contentType: false,
                data: fd
            }).done(function (data) {
                console.log(data);
                info.Image = data;
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
        /*        location.href = '/Products/Detail?id=' + objId;*/
        abp.ajax({
            url: abp.appPath + 'Products/EditImageModal?id=' + objId + '&productId=' + _$productId,
            type: 'Get',
            dataType: 'html',
            /*data: { id: objId, productId = _$productId },*/
            success: function (content) {
                $('#EditModal div.modal-content').html(content);
            },
            error: function (e) {
            }
        });
    });

    $(document).on('click', 'a[data-target="#CreateOrEditModal"]', (e) => {
        $('.modal fade').tab('show')
    });

    abp.event.on('Image.edited', (data) => {
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

})(jQuery);


