import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  styled,
  IconButton,
} from '@mui/material';
import { tableCellClasses } from '@mui/material/TableCell';
import { purpleTheme } from '../../theme/purpleTheme';
import ModeEditIcon from '@mui/icons-material/ModeEdit';
import DeleteIcon from '@mui/icons-material/Delete';
import { useNavigate } from 'react-router-dom';
import { Plate } from '../modals/Plate.models';
import dayjs from 'dayjs';
import { useDispatch, useSelector } from 'react-redux';
import { AnyAction, ThunkDispatch } from '@reduxjs/toolkit';
import { RootState } from '~/store';
import { ThunkDeletePlate, ThunkGetPlate } from '~/store/plate/thunks';
import { useEffect, useState } from 'react';
import PlateDialogView from './PlateDialogView';

const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: purpleTheme.palette.primary.main,
    color: theme.palette.common.white,
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
  },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
  '&:nth-of-type(odd)': {
    backgroundColor: theme.palette.action.hover,
  },
  // hide last border
  '&:last-child td, &:last-child th': {
    border: 0,
  },
}));

export default function PlateTableView() {
  const dispatch = useDispatch<ThunkDispatch<RootState, unknown, AnyAction>>();
  const { plates = [] } = useSelector((state: any) => state.plate);
  const { initialAuth } = useSelector((state: any) => state.auth);
  const navigate = useNavigate();

  const handleUpdate = (plate: Plate) => {
    navigate(`/plate/update/${plate.id}`);
  };

  useEffect(() => {
    dispatch(ThunkGetPlate(initialAuth.uid));
  }, [dispatch, plates]);

  const handleDelete = (id: string) => {
    handleOpenDialog();
    setId(id);
  };

  const [open, setOpen] = useState<boolean>(false);
  const [id, setId] = useState<string>('');
  const handleOpenDialog = () => {
    setOpen(true);
  };

  const handleCloseDialog = () => {
    setOpen(false);
  };

  const handleActionDialog = () => {
    dispatch(ThunkDeletePlate(id));
    setOpen(false);
    navigate(`/plate`);
  };
  return (
    <>
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 700 }} aria-label='customized table'>
          <TableHead>
            <TableRow>
              <StyledTableCell align='right'>Id</StyledTableCell>
              <StyledTableCell align='right'>Name</StyledTableCell>
              <StyledTableCell align='right'>Date</StyledTableCell>
              <StyledTableCell align='right'>Offer</StyledTableCell>
              <StyledTableCell align='right'>Update</StyledTableCell>
              <StyledTableCell align='right'>Delete</StyledTableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {plates.map((plate: Plate) => (
              <StyledTableRow key={plate.id}>
                <StyledTableCell align='right'>{plate.id}</StyledTableCell>
                <StyledTableCell align='right'>{plate.name}</StyledTableCell>
                <StyledTableCell align='right'>
                  {dayjs(plate.dateActivity).format('YYYY-MM-DD')}
                </StyledTableCell>
                <StyledTableCell align='right'>{plate.offer.toString()}</StyledTableCell>
                <StyledTableCell align='right'>
                  <IconButton color='inherit' onClick={() => handleUpdate(plate)}>
                    {' '}
                    <ModeEditIcon />
                  </IconButton>
                </StyledTableCell>
                <StyledTableCell align='right'>
                  {' '}
                  <IconButton color='inherit' onClick={() => handleDelete(plate?.id ?? '')}>
                    {' '}
                    <DeleteIcon />
                  </IconButton>
                </StyledTableCell>
              </StyledTableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
      <PlateDialogView
        open={open}
        title={'Confirmation'}
        message='Do you want to delete this plate?'
        handleClose={handleCloseDialog}
        action={handleActionDialog}
      ></PlateDialogView>
    </>
  );
}
