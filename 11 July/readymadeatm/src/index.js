import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import Aos from 'aos';
import App from './App';

const root = ReactDOM.createRoot(document.getElementById('root'));
Aos.init();

root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);
