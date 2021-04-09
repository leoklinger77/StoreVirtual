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
    $('.btn-image-excluir').click(function () {
        var campoHidden = $(this).parent().find('input[name=imagem]');
        var image = $(this).parent().find('.img-upload');
        $.ajax({
            type: "GET",
            url: "/Funcionario/Imagem/RemoveImage?caminho=" + campoHidden.val(),
            contentType: false,
            processData: false,
            error: function () {
                
            },
            success: function (data) {
                image.attr("src", "/Img/img_padrao.png");
            }
        })
    })

    $('.input-file').change(function () {
        var file = new FormData();

        file.append('file', $(this)[0].files[0]);
        var campoHidden = $(this).parent().find('input[name=imagem]');
        var image = $(this).parent().find('.img-upload');

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
                image.attr("src", data.caminho);
                campoHidden.val(data.caminho);
                
            }
        });
    });
}