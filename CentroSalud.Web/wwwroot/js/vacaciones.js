console.log("vacaciones.js cargado");

// protección
if (!window.vacaciones) {
    window.vacaciones = [];
}

document.addEventListener("DOMContentLoaded", () => {

    console.log("DOM listo - vacaciones");

    cargarSelectMedicos();

    document.getElementById("btnGuardar")
        .addEventListener("click", guardarVacacion);

    document.getElementById("btnCargar")
        .addEventListener("click", cargarVacaciones);
});


// CARGAR SELECT DE MÉDICOS
function cargarSelectMedicos() {

    console.log("Cargando médicos en select...");
    console.log("Lista médicos:", window.medicos);

    const select = document.getElementById("medicoId");

    if (!select) {
        console.error("Select no encontrado");
        return;
    }

    select.innerHTML = "";

    if (!window.medicos || window.medicos.length === 0) {
        select.innerHTML = `<option>No hay médicos</option>`;
        return;
    }

    window.medicos.forEach(m => {
        select.innerHTML += `
            <option value="${m.id}">
                ${m.nombre}
            </option>
        `;
    });
}


// GUARDAR
function guardarVacacion() {

    const medicoId = document.getElementById("medicoId").value;
    const inicio = document.getElementById("fechaInicio").value;
    const fin = document.getElementById("fechaFin").value;

    console.log("Datos:", { medicoId, inicio, fin });

    if (!medicoId || !inicio || !fin) {
        alert("Completa todos los campos");
        return;
    }

    const nueva = {
        id: Date.now(),
        medicoId,
        inicio,
        fin
    };

    console.log("Creando vacación:", nueva);

    window.vacaciones.push(nueva);

    cargarVacaciones();
}


// CARGAR TABLA
function cargarVacaciones() {

    console.log("Cargando vacaciones...");
    console.log("Vacaciones:", window.vacaciones);

    const tabla = document.getElementById("tabla");
    tabla.innerHTML = "";

    window.vacaciones.forEach(v => {

        const medico = window.medicos.find(m => m.id == v.medicoId);

        console.log("Fila:", v, medico);

        tabla.innerHTML += `
            <tr>
                <td>${v.id}</td>
                <td>${medico ? medico.nombre : "NO EXISTE"}</td>
                <td>${v.inicio}</td>
                <td>${v.fin}</td>
            </tr>
        `;
    });
}