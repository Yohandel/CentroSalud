console.log("pacientes.js cargado");

// protección por si data.js no cargó
if (!window.pacientes) {
    console.warn("window.pacientes no existía, se crea");
    window.pacientes = [];
}

let idEditando = null;

document.addEventListener("DOMContentLoaded", () => {

    console.log("DOM listo - pacientes");

    const btnCargar = document.getElementById("btnCargar");
    const btnGuardar = document.getElementById("btnGuardar");

    console.log("Botones:", { btnCargar, btnGuardar });

    if (btnCargar) {
        btnCargar.addEventListener("click", cargarPacientes);
    }

    if (btnGuardar) {
        btnGuardar.addEventListener("click", guardarPaciente);
    }
});


// CARGAR
function cargarPacientes() {

    console.log("Cargando pacientes...");
    console.log("Lista:", window.pacientes);

    const tabla = document.getElementById("tabla");

    if (!tabla) {
        console.error("Tabla no encontrada");
        return;
    }

    tabla.innerHTML = "";

    window.pacientes.forEach(p => {

        console.log("Paciente:", p);

        tabla.innerHTML += `
            <tr>
                <td>${p.id}</td>
                <td>${p.nombre}</td>
                <td>${p.edad}</td>
                <td>${p.telefono}</td>
                <td>
                    <button onclick="editarPaciente(${p.id})">Editar</button>
                    <button onclick="eliminarPaciente(${p.id})">Eliminar</button>
                </td>
            </tr>
        `;
    });
}


// GUARDAR
function guardarPaciente() {

    console.log("Guardando paciente...");

    const nombreInput = document.getElementById("nombre");
    const edadInput = document.getElementById("edad");
    const telefonoInput = document.getElementById("telefono");

    if (!nombreInput || !edadInput || !telefonoInput) {
        console.error("Faltan inputs");
        return;
    }

    const nombre = nombreInput.value;
    const edad = edadInput.value;
    const telefono = telefonoInput.value;

    console.log("Datos:", { nombre, edad, telefono });

    if (!nombre || !edad || !telefono) {
        alert("Completa todos los campos");
        return;
    }

    if (idEditando === null) {

        const nuevo = {
            id: Date.now(),
            nombre,
            edad,
            telefono
        };

        console.log("Creando paciente:", nuevo);

        window.pacientes.push(nuevo);

    } else {

        const p = window.pacientes.find(x => x.id === idEditando);

        console.log("Editando paciente:", p);

        if (!p) {
            console.error("Paciente no encontrado");
            return;
        }

        p.nombre = nombre;
        p.edad = edad;
        p.telefono = telefono;

        idEditando = null;
    }

    console.log("Lista final:", window.pacientes);

    limpiarFormulario();
    cargarPacientes();
}


// EDITAR
function editarPaciente(id) {

    console.log("Editar ID:", id);

    const p = window.pacientes.find(x => x.id === id);

    if (!p) {
        console.error("Paciente no encontrado");
        return;
    }

    document.getElementById("nombre").value = p.nombre;
    document.getElementById("edad").value = p.edad;
    document.getElementById("telefono").value = p.telefono;

    idEditando = id;
}


// ELIMINAR
function eliminarPaciente(id) {

    console.log("Eliminando ID:", id);

    window.pacientes = window.pacientes.filter(x => x.id !== id);

    console.log("Lista después:", window.pacientes);

    cargarPacientes();
}


// LIMPIAR
function limpiarFormulario() {

    console.log("Limpiando formulario");

    document.getElementById("nombre").value = "";
    document.getElementById("edad").value = "";
    document.getElementById("telefono").value = "";
}