console.log("medicos.js cargado");

let idEditando = null;

document.addEventListener("DOMContentLoaded", () => {

    console.log("DOM listo - medicos");

    const btnCargar = document.getElementById("btnCargar");
    const btnGuardar = document.getElementById("btnGuardar");

    console.log("Botones:", { btnCargar, btnGuardar });

    if (btnCargar) {
        btnCargar.addEventListener("click", cargarMedicos);
    }

    if (btnGuardar) {
        btnGuardar.addEventListener("click", guardarMedico);
    }
});

function cargarMedicos() {

    console.log("Cargando medicos...");
    console.log("Lista actual:", window.medicos);

    const tabla = document.getElementById("tabla");

    if (!tabla) {
        console.error("Tabla no encontrada");
        return;
    }

    tabla.innerHTML = "";

    window.medicos.forEach(m => {
        tabla.innerHTML += `
            <tr>
                <td>${m.id}</td>
                <td>${m.nombre}</td>
                <td>
                    <button onclick="editarMedico(${m.id})">Editar</button>
                    <button onclick="eliminarMedico(${m.id})">Eliminar</button>
                </td>
            </tr>
        `;
    });
}

function guardarMedico() {

    console.log("Guardando medico...");

    const input = document.getElementById("nombre");

    if (!input) {
        console.error("Input nombre no existe");
        return;
    }

    const nombre = input.value;

    console.log("Nombre ingresado:", nombre);

    if (!nombre) {
        console.warn("Nombre vacío");
        alert("Ingrese un nombre");
        return;
    }

    if (idEditando === null) {

        const nuevo = {
            id: Date.now(),
            nombre
        };

        console.log("Creando medico:", nuevo);

        window.medicos.push(nuevo);

    } else {

        const m = window.medicos.find(x => x.id === idEditando);

        console.log("Editando medico:", m);

        if (!m) {
            console.error("No encontrado");
            return;
        }

        m.nombre = nombre;

        idEditando = null;
    }

    console.log("Lista final medicos:", window.medicos);

    input.value = "";

    cargarMedicos();
}

function editarMedico(id) {

    console.log("Editar medico ID:", id);

    const m = window.medicos.find(x => x.id === id);

    if (!m) {
        console.error("Medico no encontrado");
        return;
    }

    document.getElementById("nombre").value = m.nombre;

    idEditando = id;
}

function eliminarMedico(id) {

    console.log("Eliminando medico ID:", id);

    window.medicos = window.medicos.filter(x => x.id !== id);

    console.log("Lista después de eliminar:", window.medicos);

    cargarMedicos();
}