export function initializeTable(tableId, options) {
    return new window.SimpleDataTable(document.getElementById(tableId), options);
}

export function refreshTable(instance) {
    instance.refresh();
}

export function destroyTable(instance) {
    instance.destroy();
}