import axios from 'axios';
const BASE_URL_2='https://localhost:7188/api' 

export default axios.create({
    baseURL:BASE_URL_2
});

export const axiosPrivate = axios.create({
    baseURL:BASE_URL_2,
    headers: {
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Headers': 'POST, GET, PUT, DELETE, OPTIONS, HEAD, Authorization, Origin, Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers, Access-Control-Allow-Origin',
        'Content-Type': 'application/json',
    }
});