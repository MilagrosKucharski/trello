$(document).ready(function() {
    // Selecciona los elementos arrastrables
    const draggableItems = document.querySelectorAll('#draggable-list .list-group-item');

    // Agrega eventos de arrastre a los elementos
    draggableItems.forEach(item => {
        item.addEventListener('dragstart', e => {
            e.dataTransfer.setData('text/plain', item.textContent.trim());
        });
    });

    // Agrega evento de soltado al área de destino
    const droppableArea = document.getElementById('droppable-area');
    droppableArea.addEventListener('dragover', e => {
        e.preventDefault();
    });

    droppableArea.addEventListener('drop', e => {
        e.preventDefault();
        const data = e.dataTransfer.getData('text/plain');
        const newItem = document.createElement('div');
        newItem.classList.add('list-group-item', 'list-group-item-action');
        newItem.textContent = data;
        droppableArea.querySelector('.card-body').appendChild(newItem);
    });
});
