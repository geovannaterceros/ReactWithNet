import AppRouter from './router/AppRouter';
import AppTheme from './theme/AppTheme';

export default function AppPlate() {
  return (
    <AppTheme>
      <AppRouter />
    </AppTheme>
  );
}
