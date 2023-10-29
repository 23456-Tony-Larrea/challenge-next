export const LOGIN_SUCCESS = "LOGIN_SUCCESS";
export const LOGOUT = "LOGOUT";

export const loginSuccess = (userId) => (dispatch) => {
  // 24 horas (en milisegundos) a la hora actual para expirar
  const sessionExpiration = Date.now() + 24 * 60 * 60 * 1000;

  dispatch({
    type: LOGIN_SUCCESS,
    payload: { userId, sessionExpiration },
  });
};

export const logout = () => ({
  type: LOGOUT,
});