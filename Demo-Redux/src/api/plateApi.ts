import axios from 'axios';

export const plateApi = axios.create({
  baseURL: 'https://localhost:5173/api',
});
