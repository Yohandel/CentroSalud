console.log("empleados.js cargado");

// protección
if (!window.empleados) {
    console.warn("window.empleados no existía, se crea");
    window.empleados = [];
}

let idEditando = null;

document.addEventListener("DOMContentLoaded", () => {

    console.log("DOM listo - empleados");

    document.getElementById("btnCargar")
        .addEventListener("click", cargarEmpleados);

    document.getElementById("btnGuardar")
        .addEventListener("click", guardarEmpleado);
});


// CARGAR
function cargarEmpleados() {

    console.log("Cargando empleados...");
    console.log("Lista:", window.empleados);

    const tabla = document.getElementById("tabla");
    tabla.innerHTML = "";

    window.empleados.forEach(e => {

        console.log("Empleado:", e);

        tabla.innerHTML += `
            <tr>
                <td>${e.id}</td>
                <td>${e.nombre}</td>
                <td>${e.cargo}</td>
                <td>${e.departamento}</td>
                <td>
                    <button onclick="editarEmpleado(${e.id})">Editar</button>
                    <button onclick="eliminarEmpleado(${e.id})">Eliminar</button>
                </td>
            </tr>
        `;
    });
}


// GUARDAR
function guardarEmpleado() {

    console.log("Guardando empleado...");

    const nombre = document.getElementById("nombre").value;
    const cargo = document.getElementById("cargo").value;
    const departamento = document.getElementById("departamento").value;

    console.log("Datos:", { nombre, cargo, departamento });

    if (!nombre || !cargo || !departamento) {
        alert("Completa todos los campos");
        return;
    }

    if (idEditando === null) {

        const nuevo = {
            id: Date.now(),
            nombre,
            cargo,
            departamento
        };

        console.log("Creando empleado:", nuevo);

        window.empleados.push(nuevo);

    } else {

        const e = window.empleados.find(x => x.id === idEditando);

        console.log("Editando empleado:", e);

        e.nombre = nombre;
        e.cargo = cargo;
        e.departamento = departamento;

        idEditando = null;
    }

    console.log("Lista final:", window.empleados);

    limpiarFormulario();
    cargarEmpleados();
}


// EDITAR
function editarEmpleado(id) {

    console.log("Editar ID:", id);

    const e = window.empleados.find(x => x.id === id);

    document.getElementById("nombre").value = e.nombre;
    document.getElementById("cargo").value = e.cargo;
    document.getElementById("departamento").value = e.departamento;

    idEditando = id;
}


// ELIMINAR
function eliminarEmpleado(id) {

    console.log("Eliminando ID:", id);

    window.empleados = window.empleados.filter(x => x.id !== id);

    console.log("Lista después:", window.empleados);

    cargarEmpleados();
}


// LIMPIAR
function limpiarFormulario() {

    console.log("Limpiando formulario");

    document.getElementById("nombre").value = "";
    document.getElementById("cargo").value = "";
    document.getElementById("departamento").value = "";
}