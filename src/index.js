import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux'; // Asegúrate de importar el Provider
import store from './redux/store'; // Asegúrate de importar tu store de Redux
import App from './App'; // Reemplaza 'App' con el nombre de tu componente principal

ReactDOM.render(
  <Provider store={store}>
    <App />
  </Provider>,
  document.getElementById('root')
);
