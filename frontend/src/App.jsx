import { useEffect, useState } from "react";
import CargaJson from "./components/CargaJson";
import SucursalesPanel from "./components/SucursalesPanel";
import { listarSucursales } from "./services/servicioApi";

export default function App() {
  const [sucursales, setSucursales] = useState([]);
  const [cargando, setCargando] = useState(true);
  const [aviso, setAviso] = useState(null);

  const mostrarMensaje = (texto, tipo = "ok") => {
    setAviso({ texto, tipo });
    setTimeout(() => setAviso(null), 4000);
  };

  const cargarSucursales = async () => {
    setCargando(true);
    try {
      const data = await listarSucursales();
      setSucursales(data);
    } catch (err) {
      mostrarMensaje(err.message, "error");
    } finally {
      setCargando(false);
    }
  };

  useEffect(() => {
    cargarSucursales();
  }, []);

  return (
    <div className="min-h-screen bg-slate-100 text-slate-800">
      <header className="bg-slate-900 text-white py-4 px-4 shadow">
        <div className="max-w-6xl mx-auto">
          <h1 className="text-lg font-bold">DAS GLOBAL S.A.</h1>
        </div>
      </header>

      <main className="max-w-6xl mx-auto px-4 py-8 space-y-6">
        {aviso && (
          <div
            className={`px-4 py-3 rounded-lg text-sm font-medium border ${
              aviso.tipo === "ok"
                ? "bg-emerald-50 text-emerald-800 border-emerald-200"
                : "bg-rose-50 text-rose-800 border-rose-200"
            }`}
          >
            {aviso.texto}
          </div>
        )}

        <CargaJson onCargado={cargarSucursales} onMensaje={mostrarMensaje} />
        <SucursalesPanel
          sucursales={sucursales}
          cargando={cargando}
          onActualizarLista={cargarSucursales}
          onMensaje={mostrarMensaje}
        />
      </main>
    </div>
  );
}