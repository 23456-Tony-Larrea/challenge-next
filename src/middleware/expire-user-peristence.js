// expire-user-persistence.js

// Esta función middleware se ejecutará cada vez que se despache una acción.
const expireUserPersistence = (store) => (next) => (action) => {
    // Capturamos la hora actual cuando se despacha la acción.
    const currentTime = Date.now();
  
    // Verificamos si el usuario está autenticado y si existe un tiempo de expiración en el estado de Redux.
    const { isAuthenticated, sessionExpiration } = store.getState().auth;
  
    // Si el usuario está autenticado y la sesión ha expirado, desencadenamos una acción de logout.
    if (isAuthenticated && currentTime > sessionExpiration) {
      store.dispatch({ type: 'LOGOUT' });
      localStorage.removeItem('Id'); // También puedes limpiar el ID almacenado en localStorage aquí
    }
  
    // Continuamos con el siguiente middleware o la acción original.
    return next(action);
  };
  
  export default expireUserPersistence;