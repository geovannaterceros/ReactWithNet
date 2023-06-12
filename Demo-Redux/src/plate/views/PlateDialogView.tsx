import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
} from '@mui/material';

interface Props {
  title: string;
  message: string;
  handleClose: React.MouseEventHandler<HTMLButtonElement>;
  action: React.MouseEventHandler<HTMLButtonElement>;
  open: boolean;
}

export default function PlateDialogView(props: Props) {
  const { title, message, handleClose, action, open } = props;
  return (
    <Dialog open={open} onClose={handleClose} aria-labelledby='draggable-dialog-title'>
      <DialogTitle style={{ cursor: 'move' }} id='draggable-dialog-title'>
        {title}
      </DialogTitle>
      <DialogContent>
        <DialogContentText>{message}</DialogContentText>
      </DialogContent>
      <DialogActions>
        <Button onClick={handleClose}>Cancel</Button>
        <Button onClick={action}>Confirm</Button>
      </DialogActions>
    </Dialog>
  );
}
