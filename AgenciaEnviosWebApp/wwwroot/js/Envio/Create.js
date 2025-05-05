document.querySelector("#Dto_TipoEnvio").addEventListener('change', MostrarDatosPropiosTipoEnvio);
MostrarDatosPropiosTipoEnvio();
function MostrarDatosPropiosTipoEnvio() {
    let tipoSel = document.querySelector("#Dto_TipoEnvio").value;

    if (tipoSel == "comun") {
        document.querySelector("#opcionesUrgente").style.display = "none";
        document.querySelector("#opcionesComun").style.display = "block";
    } else {
        document.querySelector("#opcionesUrgente").style.display = "block";
        document.querySelector("#opcionesComun").style.display = "none";
    }
}