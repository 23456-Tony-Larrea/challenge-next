export const LOGIN_SUCCESS = "LOGIN_SUCCESS";
export const LOGOUT = "LOGOUT";

export const loginSuccess = (userId) => (dispatch) => {
    dispatch({
      type: 'LOGIN_SUCCESS',
      payload: { userId, sessionExpiration: Date.now() + 60000 }, // Establece la expiración de sesión en 1 minuto
    });
}  

export const logout = () => ({
  type: LOGOUT,
});