

function Salvar() {

    var url_atual = window.location.origin;

    var model = JSON.parse($("#model").val());
    model.Nome = $("#Nome").val();


    if (model.Nome == "") {

        swal({
            position: 'top-end',
            type: 'error',
            title: "Favor Colocar Nome",
            showConfirmButton: false,
            timer: 1500
        })

    }  else {


        $.ajax({
            type: 'POST',
            url: url_atual + '/Time/Salvar',
            data: model,
            success: function (data) {
                if (data == "Ok") {
                    swal({
                        position: 'top-end',
                        type: 'success',
                        title: 'Cadastrado com Sucesso',
                        showConfirmButton: false,
                        timer: 1500
                    })

                    var url = window.location.origin + '/Time/Listar';
                    window.location.href = url;

                }
                else {

                    swal({
                        position: 'top-end',
                        type: 'error',
                        title: data,
                        showConfirmButton: false,
                        timer: 1500
                    })
                }

            }
        });

    }



}
