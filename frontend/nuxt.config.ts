// https://nuxt.com/docs/api/configuration/nuxt-config
import tailwindcss from "@tailwindcss/vite";

export default defineNuxtConfig({
  css: ["~/assets/css/tailwind.css"],
  ssr: false,
  vite: {
    plugins: [tailwindcss()],
  },
  /* experimental: {
    watcher: "chokidar",
  }, */
  compatibilityDate: "2025-05-28",
  devtools: { enabled: false },
  modules: ["@nuxt/eslint", "shadcn-nuxt",],

  shadcn: {
    prefix: "",
    componentDir: "./components/ui",
  },
});
