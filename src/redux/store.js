
import { createStore, applyMiddleware } from 'redux';
import rootReducer from './reducer';
import expireUserPersistence from '../middleware/expire-user-peristence'; // Importa tu middleware

const store = createStore(rootReducer, applyMiddleware(expireUserPersistence));

export default store;