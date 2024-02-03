// Cork Pagination Data Table

c1 = $('#style-1').DataTable({
    headerCallback: function (e, a, t, n, s) {
        // e.getElementsByTagName("th")[0].innerHTML =
        //     /*html*/
        //     `
        //     <div class="form-check form-check-primary d-block">
        //         <input class="form-check-input chk-parent" type="checkbox" id="form-check-default">
        //     </div>
        //     `

    },
    columnDefs: [{
        targets: 0, width: "30px", className: "", orderable: !1, render: function (e, a, t, n) {

            return e;
            // return /*html*/`
            //     <div class="form-check form-check-primary d-block">

            //         <input class="form-check-input child-chk" type="checkbox" id="form-check-default">
            //     </div>`
        }
    }],
    "dom": "<'dt--top-section'<'row'<'col-6 d-flex justify-content-end mt-sm-0 mt-3'f>>>" + "<'table-responsive'tr>",
        // "<'dt--bottom-section d-sm-flex justify-content-sm-between text-center'<'dt--pages-count  mb-sm-0 mb-3'i><'dt--pagination'p>>",
    "oLanguage": {
        "oPaginate": { 
            "sPrevious": '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-arrow-left"><line x1="19" y1="12" x2="5" y2="12"></line><polyline points="12 19 5 12 12 5"></polyline></svg>',
            "sNext": '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-arrow-right"><line x1="5" y1="12" x2="19" y2="12"></line><polyline points="12 5 19 12 12 19"></polyline></svg>' 
        },
        "sInfo": "Sayfa _PAGE_ / _PAGES_",
        "sSearch": '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-search"><circle cx="11" cy="11" r="8"></circle><line x1="21" y1="21" x2="16.65" y2="16.65"></line></svg>',
        "sSearchPlaceholder": "Sayfada ara...",
        "sLengthMenu": "Göster :  _MENU_",
    },
    "lengthMenu": [],
    "pageLength": 1000
});

multiCheck(c1);