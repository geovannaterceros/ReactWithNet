import { Grid, Typography } from '@mui/material';

interface Props {
  children: React.ReactElement;
  title: string;
}
export default function PlateLayoutForm(props: Props) {
  const { children, title } = props;
  return (
    <Grid
      container
      spacing={0}
      direction='column'
      alignItems='center'
      justifyContent='flex-start'
      sx={{
        minHeight: '100vh',
        backgroundColor: 'primary.main',
        padding: 4,
        borderRadius: '1% 1% 0 0',
      }}
    >
      <Grid
        item
        className='box-shadow'
        xs={3}
        sx={{
          width: { sm: 450 },
          backgroundColor: 'white',
          padding: 3,
          borderRadius: 2,
        }}
      >
        <Typography variant='h5' sx={{ mb: 1 }}>
          {title}
        </Typography>
        {children}
      </Grid>
    </Grid>
  );
}
