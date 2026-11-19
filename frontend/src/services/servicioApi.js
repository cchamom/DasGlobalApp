const API_URL = "http://localhost:5147/api/Empresa";

export async function listarSucursales() {
  const res = await fetch(API_URL);
  const data = await res.json().catch(() => null);
  if (!res.ok) throw new Error(data?.mensaje || "Error al cargar sucursales.");
  return data;
}

export async function cargarJsonEmpresa(archivo) {
  const formData = new FormData();
  formData.append("archivoJson", archivo);

  const res = await fetch(`${API_URL}/cargar-json`, {
    method: "POST",
    body: formData,
  });
  const data = await res.json().catch(() => null);
  if (!res.ok) throw new Error(data?.mensaje || "Error al subir el JSON.");
  return data;
}

export async function actualizarSucursal(id, payload) {
  const res = await fetch(`${API_URL}/sucursal/${id}`, {
    method: "PATCH",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(payload),
  });
  const data = await res.json().catch(() => null);
  if (!res.ok) throw new Error(data?.mensaje || "Error al editar sucursal.");
  return data;
}

export async function eliminarSucursal(id) {
  const res = await fetch(`${API_URL}/sucursal/${id}`, {
    method: "DELETE",
  });
  const data = await res.json().catch(() => null);
  if (!res.ok) throw new Error(data?.mensaje || "Error al eliminar sucursal.");
  return data;
}