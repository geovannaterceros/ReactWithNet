import { Box, Toolbar } from '@mui/material';
import NavBar from '~/ui/NavBar';

interface Props {
  children: React.ReactElement;
}
export default function PlateLayout(props: Props) {
  const { children } = props;
  return (
    <Box sx={{ display: 'flex' }}>
      <NavBar title='Geovanna' />
      <Box component='main' sx={{ flexGrow: 1, p: 3 }}>
        <Toolbar />
        {children}
      </Box>
    </Box>
  );
}
