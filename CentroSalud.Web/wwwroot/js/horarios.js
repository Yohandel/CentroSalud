console.log("horarios.js cargado");

let idEditando = null;

document.addEventListener("DOMContentLoaded", () => {

    console.log("DOM listo - horarios");

    const btnCargar = document.getElementById("btnCargar");
    const btnGuardar = document.getElementById("btnGuardar");

    console.log("Botones:", { btnCargar, btnGuardar });

    if (btnCargar) {
        btnCargar.addEventListener("click", cargarHorarios);
    }

    if (btnGuardar) {
        btnGuardar.addEventListener("click", guardarHorario);
    }
});

function cargarHorarios() {

    console.log("Cargando horarios...");
    console.log("Horarios:", window.horarios);
    console.log("Medicos:", window.medicos);

    const tabla = document.getElementById("tabla");

    if (!tabla) {
        console.error("Tabla no encontrada");
        return;
    }

    tabla.innerHTML = "";

    window.horarios.forEach(h => {

        console.log("Procesando horario:", h);

        const medico = window.medicos.find(m => m.id == h.medicoId);

        console.log("Resultado medico:", medico);

        tabla.innerHTML += `
            <tr>
                <td>${h.id}</td>
                <td>${h.diaTexto}</td>
                <td>${h.inicio}</td>
                <td>${h.fin}</td>
                <td>${medico ? medico.nombre : ""}</td>
                <td>
                    <button onclick="eliminarHorario(${h.id})">Eliminar</button>
                </td>
            </tr>
        `;
    });

    console.log("Tabla renderizada");
}

function guardarHorario() {

    console.log("Guardando horario...");

    const diaSelect = document.getElementById("dia");
    const inicioInput = document.getElementById("inicio");
    const finInput = document.getElementById("fin");
    const medicoInput = document.getElementById("medicoId");

    if (!diaSelect || !inicioInput || !finInput || !medicoInput) {
        console.error("Faltan inputs");
        return;
    }

    const dia = diaSelect.value;
    const diaTexto = diaSelect.options[diaSelect.selectedIndex].text;
    const inicio = inicioInput.value;
    const fin = finInput.value;
    const medicoId = medicoInput.value;

    console.log("Datos:", { dia, inicio, fin, medicoId });

    if (!inicio || !fin || !medicoId) {
        console.warn("Campos incompletos");
        alert("Completa todos los campos");
        return;
    }

    if (inicio >= fin) {
        console.warn("Hora inválida");
        alert("Hora inválida");
        return;
    }

    const nuevo = {
        id: Date.now(),
        dia,
        diaTexto,
        inicio,
        fin,
        medicoId
    };

    console.log("Creando horario:", nuevo);

    window.horarios.push(nuevo);

    console.log("Lista horarios:", window.horarios);

    limpiarFormulario();
    cargarHorarios();
}

function eliminarHorario(id) {

    console.log("Eliminando horario ID:", id);

    window.horarios = window.horarios.filter(x => x.id !== id);

    console.log("Lista después:", window.horarios);

    cargarHorarios();
}

function limpiarFormulario() {

    console.log("Limpiando formulario");

    document.getElementById("inicio").value = "";
    document.getElementById("fin").value = "";
    document.getElementById("medicoId").value = "";
}