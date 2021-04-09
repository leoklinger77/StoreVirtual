$(document).ready(function () {
    $('.excluir').click(function (e) {
        var result = confirm("Tem certeza que deseja Excluir este registro?");

        if (result == true) {
            return;
        }
        e.preventDefault();        
    });
    $('.money').mask('000.000.000.000.000.00', { reverse: true });


    AjaxUploadImageProduto()


});


function AjaxUploadImageProduto() {
    $('.img-upload').click(function () {
        $(this).parent().find('.input-file').click();
    });

    $('.input-file').change(function () {
        var file = new FormData();

        file.append('file', $(this)[0].files[0]);

        $.ajax({
            type: "POST",
            url: "/Funcionario/Imagem/InsertImage",
            data: file,
            contentType: false,
            processData: false,
            error: function () {
                alert("Erro ao enviar foto");
            },
            success: function (data) {
                alert("Arquivod enviado com sucesso" + data.caminho);
            }
        });
    });
}