$(document).ready(function () {
    $('.excluir').click(function (e) {
        var result = confirm("Tem certeza que deseja Excluir este registro?");

        if (result == true) {
            return;
        }
        e.preventDefault();        
    });
    $('.money').mask('000.000.000.000.000.00', { reverse: true });
});