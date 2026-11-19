import { useState } from "react";
import { cargarJsonEmpresa } from "../services/servicioApi";

export default function CargaJson({ onCargado, onMensaje }) {
  const [archivo, setArchivo] = useState(null);
  const [subiendo, setSubiendo] = useState(false);
  const [resetKey, setResetKey] = useState(0);

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!archivo) return;

    setSubiendo(true);
    try {
      const resp = await cargarJsonEmpresa(archivo);
      onMensaje(resp?.mensaje || "Archivo JSON guardado en la base de datos.", "ok");
      setArchivo(null);
      setResetKey((k) => k + 1);
      await onCargado();
    } catch (err) {
      onMensaje(err.message, "error");
    } finally {
      setSubiendo(false);
    }
  };

  return (
    <section className="bg-white rounded-xl shadow-sm border border-slate-200 p-6">
      <h2 className="text-base font-semibold text-slate-900 mb-3">
        Cargar archivo JSON
      </h2>

      <form onSubmit={handleSubmit} className="flex flex-col sm:flex-row gap-3">
        <input
          key={resetKey}
          type="file"
          accept=".json,application/json"
          onChange={(e) => setArchivo(e.target.files?.[0] || null)}
          className="block w-full text-sm text-slate-600 file:mr-4 file:py-2 file:px-4 file:rounded-lg file:border-0 file:text-sm file:font-semibold file:bg-blue-50 file:text-blue-700 hover:file:bg-blue-100 border border-slate-300 rounded-lg cursor-pointer"
        />
        <button
          type="submit"
          disabled={!archivo || subiendo}
          className="sm:w-48 bg-blue-600 hover:bg-blue-700 disabled:opacity-60 text-white text-sm font-semibold px-4 py-2.5 rounded-lg transition shrink-0"
        >
          {subiendo ? "Guardando..." : "Subir y Guardar"}
        </button>
      </form>
    </section>
  );
}