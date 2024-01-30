import axios from 'axios';

 export const customAxios = () => {
  const instance = axios.create({
    headers: {
      Authorization: `Bearer ${localStorage.getItem('token')}`,
    },
  });
  return instance;
};
 
export const api = axios.create({
  baseURL: 'http://localhost:3001',
});

 