import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import checker from 'vite-plugin-checker'
import eslintPlugin from '@nabla/vite-plugin-eslint'

// https://vitejs.dev/config/
export default defineConfig({
  base: '/',
  plugins: [
    eslintPlugin(), 
    react(),
    checker({
      overlay: {
        initialIsOpen: true,
      },
      typescript: true,
    }),
  ],
  build: {
    outDir: 'build',
  },
  server: {
    https: false,
    port: 5173,
  },
})
