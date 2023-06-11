import { ThemeProvider } from '@emotion/react';
import { CssBaseline } from '@mui/material';
import { purpleTheme } from './purpleTheme';
import React from 'react';

export interface Props {
  children: React.ReactElement;
}

export default function AppTheme(props: Props) {
  const { children } = props;
  return (
    <ThemeProvider theme={purpleTheme}>
      <CssBaseline />
      {children}
    </ThemeProvider>
  );
}
