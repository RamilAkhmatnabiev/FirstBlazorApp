function showSuccessSaveMessage(recordName){
    //alert(`Record Name = ${recordName ?? "NoName"} has been saved successfully`);
    debugger;
    //Взаимодействие с элементами DOM из метода JS
    let successSaveMessageInfoElement = document.getElementById("successSaveMessageInfo");
    if (successSaveMessageInfoElement){
        successSaveMessageInfoElement.innerText = `Record Name = ${recordName ?? "NoName"} has been saved successfully`;
    }
}

function setFocusOnElement(element){
    //В текущйи момент фокус не работате, но элемент приходит сюда
    debugger;
    element.focus();
}

function getCities(){
    return ['Lya-lya','topolya','hueta','mueta','pipulka','pizdulkino','ebalkino','traxalkino','pizdilkino',]
}
