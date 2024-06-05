/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./**/*.{html,js}"],
  theme: {
    extend: {
      keyframes: {
        beat: {
          '0%, 100%': { transform:'scale(1,1)' },
          '50%': { transform: 'scale(0.8,0.8)' },
        }
      },
      animation: {
        beat: 'beat 5s ease-in-out infinite',
      },
      colors:{
        'Primary':'#29303E',
        'Secondary':'#93969D',
        'Tertiary':'#249554'
      }
    },
  },
  plugins: [],
}

