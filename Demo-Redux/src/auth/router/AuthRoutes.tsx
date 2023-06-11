import { Navigate, Route, Routes } from 'react-router-dom';
import LoginPage from '../pages/LoginPage';

export default function AuthRoutes() {
  return (
    <Routes>
      <Route path='login' element={<LoginPage />} />
      <Route path='/' element={<LoginPage />} />
    </Routes>
  );
}
