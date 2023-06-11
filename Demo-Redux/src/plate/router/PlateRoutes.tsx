import { Route, Routes } from 'react-router-dom';
import PlateCreatePage from '../pages/PlateCreatePage';
import PlatePage from '../pages/PlatePage';
import PlateUpdatePage from '../pages/PlateUpdatePage';

export default function PlateRoutes() {
  return (
    <Routes>
      <Route path='/' element={<PlatePage />} />
      <Route path='/create' element={<PlateCreatePage />} />
      <Route path='/update/:id' element={<PlateUpdatePage />} />
    </Routes>
  );
}
