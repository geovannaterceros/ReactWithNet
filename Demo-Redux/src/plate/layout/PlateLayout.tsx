import { Box, Toolbar } from '@mui/material';
import { useSelector } from 'react-redux';
import NavBar from '~/ui/NavBar';

interface Props {
  children: React.ReactElement;
}
export default function PlateLayout(props: Props) {
  const { children } = props;
  const { initialAuth } = useSelector((state: any) => state.auth);

  return (
    <Box sx={{ display: 'flex' }}>
      <NavBar title={initialAuth.displayName} />
      <Box component='main' sx={{ flexGrow: 1, p: 3 }}>
        <Toolbar />
        {children}
      </Box>
    </Box>
  );
}
