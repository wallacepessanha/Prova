

function Salvar() {

    var url_atual = window.location.origin;

    var model = JSON.parse($("#model").val());

    for (var i = 0; i < model.Partida.length; i++) {

        model.Partida[i].GolsA = $("#Partida_" + i + "__GolsA").val()
        model.Partida[i].GolsB = $("#Partida_" + i + "__GolsB").val()

    }

    var PartidaId = $("#TorneioId").val();


    $.ajax({
        type: 'POST',
        url: url_atual + '/Partida/Resultado',
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

    var url = window.location.origin + '/Partida/Index/' + PartidaId;
    window.location.href = url;

}
