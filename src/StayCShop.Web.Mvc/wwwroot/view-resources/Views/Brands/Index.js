(function ($) {

    console.log("Testddfhhjhbjbkbkjbkjnn njhkljlkjl nkjkljlkjl 44444445667dfdf68666");
    l = abp.localization.getSource('StayCShop');
    var _mService = abp.services.app.brand;
    var _$table = $('#DataTable');

    //_$modal = $('#UserCreateModal');
    //_$form = _$modal.find('form');

    var _$usersTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _mService.getAll,
            inputFilter: function () {
                return $('#TableFilter').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$usersTable.draw(false)
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
                targets: 2,
                data: 'brandName',
                sortable: false,
            },
            {
                targets: 1,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-user" data-user-id="${row.id}" data-toggle="modal" data-target="#UserEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-user" data-user-id="${row.id}" data-user-name="${row.name}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });


    //var _createOrEditModal = new app.ModalManager({
    //    viewUrl: abp.appPath + 'Brands/CreateOrEditBrandModal',
    //    scriptUrl: abp.appPath + 'view-resources/Views/Brands/_CreateOrEditBrandModal.js',
    //    modalClass: 'CreateOrEditBrandModal',
    //});


    //function getData() {
    //    dataTable.ajax.reload();
    //}

    //$('#TableFilter').on('keydown', function (e) {
    //    if (e.keyCode !== 13) {
    //        return;
    //    }

    //    e.preventDefault();
    //    getData();
    //});

    //$('#CreateNewBtn').click(function (e) {
    //    e.preventDefault();
    //    _createOrEditModal.open({});
    //});

    //$('#GetButton').click(function (e) {
    //    e.preventDefault();
    //    getData();
    //});

    //abp.event.on('app.createOrEditBrandModalSaved', function () {
    //    dataTable.ajax.reload();
    //});

    //function DeleteObj(obj) {
    //    abp.message.confirm(
    //        l('DeleteWarningMessage', obj.name),
    //        l('AreYouSure'),
    //        function (isConfirmed) {
    //            if (isConfirmed) {
    //                _mService.delete({
    //                    id: obj.id
    //                }).done(function () {
    //                    getData();
    //                    abp.notify.success(l('SuccessfullyDeleted'));
    //                });
    //            }
    //        }
    //    );
    //}

})(jQuery);


