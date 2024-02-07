

function initializeDataTable() {
    $('#orderTable').DataTable({
        paging: true,        
        lengthMenu: [5,10,15,20,40,100]
    });

}
function applyFilter(filterValue) {
    var table = $('#orderTable').DataTable({
        paging: true,
        lengthMenu: [5, 10, 15, 20, 40, 100]
    });
    table.column(4).search(filterValue).draw();
}