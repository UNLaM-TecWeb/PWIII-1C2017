function mostrar($div)
    {
        $("#"+$div).show();
    }


/**
 * Le da el foco a un componente de la pagina a traves de su id. 
 * 
 * @param  {string} idComponente Es el id de algún componente válido capaz de recivir el foco. Por ejemplo: un campo de texto, una lista desplegable, etc.
 * @return {none} La función no retorna valores.
 * 
 */
function DarFoco(idComponente) {
    document.getElementById(idComponente).focus();
}
