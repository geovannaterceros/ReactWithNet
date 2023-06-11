import ReactDOM from 'react-dom/client';

import { Provider } from 'react-redux';
import { store } from './store';
import { BrowserRouter } from 'react-router-dom';
import AppPlate from './AppPlate';

ReactDOM.createRoot(document.getElementById('root')!).render(
  // <React.StrictMode>
  <BrowserRouter>
    <Provider store={store}>
      <AppPlate />
    </Provider>
  </BrowserRouter>,

  // </React.StrictMode>,
);
