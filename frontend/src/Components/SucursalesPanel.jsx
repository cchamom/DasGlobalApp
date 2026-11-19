import { useState } from "react";
import { actualizarSucursal, eliminarSucursal } from "../services/servicioApi";

export default function SucursalesPanel({
  sucursales,
  cargando,
  onActualizarLista,
  onMensaje,
}) {
  const [editando, setEditando] = useState(null);
  const [form, setForm] = useState({ nombre: "", direccion: "", telefono: "" });

  const abrirEditar = (sucursal) => {
    setEditando(sucursal);
    setForm({
      nombre: sucursal.nombre ?? "",
      direccion: sucursal.direccion ?? "",
      telefono: sucursal.telefono ?? "",
    });
  };

  const handleGuardar = async (e) => {
    e.preventDefault();
    if (!editando) return;
    try {
      const resp = await actualizarSucursal(editando.id, form);
      onMensaje(resp?.mensaje || "Sucursal actualizada.", "ok");
      setEditando(null);
      await onActualizarLista();
    } catch (err) {
      onMensaje(err.message, "error");
    }
  };

  const handleEliminar = async (sucursal) => {
    if (!window.confirm(`¿Eliminar "${sucursal.nombre}" y sus colaboradores asociados?`)) {
      return;
    }
    try {
      const resp = await eliminarSucursal(sucursal.id);
      onMensaje(resp?.mensaje || "Sucursal eliminada.", "ok");
      await onActualizarLista();
    } catch (err) {
      onMensaje(err.message, "error");
    }
  };

  return (
    <section className="bg-white rounded-xl shadow-sm border border-slate-200 p-6">
      <div className="flex items-center justify-between mb-4">
        <h2 className="text-base font-semibold text-slate-900">
          Sucursales y Colaboradores
        </h2>
        <button
          onClick={onActualizarLista}
          className="text-xs font-medium text-slate-700 hover:bg-slate-100 border border-slate-300 px-3 py-1.5 rounded-lg transition"
        >
          Actualizar
        </button>
      </div>

      {cargando ? (
        <p className="text-sm text-slate-500 py-4">Cargando registros...</p>
      ) : sucursales.length === 0 ? (
        <p className="text-sm text-slate-500 py-4">
          No hay registros cargados. Sube un archivo JSON.
        </p>
      ) : (
        <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
          {sucursales.map((s) => (
            <div
              key={s.id}
              className="border border-slate-200 rounded-xl p-4 bg-slate-50/50 flex flex-col justify-between"
            >
              <div>
                <div className="flex items-start justify-between gap-2">
                  <div>
                    <span className="text-[11px] font-semibold bg-blue-100 text-blue-800 px-2 py-0.5 rounded">
                      {s.nombreEmpresa || `Empresa #${s.idEmpresa}`}
                    </span>
                    <h3 className="text-base font-bold text-slate-900 mt-1">
                      {s.nombre}
                    </h3>
                  </div>
                  <div className="flex gap-1.5">
                    <button
                      onClick={() => abrirEditar(s)}
                      className="text-xs font-medium bg-amber-100 text-amber-900 hover:bg-amber-200 px-2.5 py-1 rounded-lg transition"
                    >
                      Editar
                    </button>
                    <button
                      onClick={() => handleEliminar(s)}
                      className="text-xs font-medium bg-rose-100 text-rose-800 hover:bg-rose-200 px-2.5 py-1 rounded-lg transition"
                    >
                      Eliminar
                    </button>
                  </div>
                </div>

                <p className="text-xs text-slate-600 mt-2">
                  <strong>Dirección:</strong> {s.direccion} · <strong>Tel:</strong> {s.telefono}
                </p>
              </div>

              <div className="mt-3 pt-3 border-t border-slate-200">
                <p className="text-xs font-semibold text-slate-700 mb-1.5">
                  Colaboradores ({s.colaboradores?.length || 0})
                </p>
                {s.colaboradores?.length ? (
                  <ul className="space-y-1">
                    {s.colaboradores.map((c) => (
                      <li
                        key={c.id}
                        className="flex justify-between text-xs bg-white border border-slate-200/80 rounded-lg px-3 py-1.5"
                      >
                        <span className="font-medium text-slate-800">{c.nombre}</span>
                        <span className="text-slate-500 font-mono">CUI: {c.cui}</span>
                      </li>
                    ))}
                  </ul>
                ) : (
                  <p className="text-xs text-slate-400 italic">Sin colaboradores</p>
                )}
              </div>
            </div>
          ))}
        </div>
      )}

      {editando && (
        <div className="fixed inset-0 bg-slate-950/50 flex items-center justify-center p-4 z-50">
          <div className="bg-white rounded-xl shadow-lg border border-slate-200 w-full max-w-md p-6">
            <h3 className="text-base font-bold text-slate-900 mb-4">
              Editar {editando.nombre}
            </h3>
            <form onSubmit={handleGuardar} className="space-y-3">
              <div>
                <label className="block text-xs font-semibold text-slate-700 mb-1">
                  Nombre
                </label>
                <input
                  type="text"
                  required
                  value={form.nombre}
                  onChange={(e) => setForm({ ...form, nombre: e.target.value })}
                  className="w-full border border-slate-300 rounded-lg px-3 py-2 text-sm"
                />
              </div>
              <div>
                <label className="block text-xs font-semibold text-slate-700 mb-1">
                  Dirección
                </label>
                <input
                  type="text"
                  required
                  value={form.direccion}
                  onChange={(e) => setForm({ ...form, direccion: e.target.value })}
                  className="w-full border border-slate-300 rounded-lg px-3 py-2 text-sm"
                />
              </div>
              <div>
                <label className="block text-xs font-semibold text-slate-700 mb-1">
                  Teléfono
                </label>
                <input
                  type="text"
                  required
                  value={form.telefono}
                  onChange={(e) => setForm({ ...form, telefono: e.target.value })}
                  className="w-full border border-slate-300 rounded-lg px-3 py-2 text-sm"
                />
              </div>
              <div className="flex justify-end gap-2 pt-2">
                <button
                  type="button"
                  onClick={() => setEditando(null)}
                  className="px-4 py-2 text-xs font-semibold text-slate-700 bg-slate-100 hover:bg-slate-200 rounded-lg"
                >
                  Cancelar
                </button>
                <button
                  type="submit"
                  className="px-4 py-2 text-xs font-semibold text-white bg-blue-600 hover:bg-blue-700 rounded-lg"
                >
                  Guardar cambios
                </button>
              </div>
            </form>
          </div>
        </div>
      )}
    </section>
  );
}