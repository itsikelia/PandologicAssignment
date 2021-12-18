import ErrorRoundedIcon from '@mui/icons-material/ErrorRounded';

function Error() {
  
  return (
    <div className='error'>
        <ErrorRoundedIcon style={{ color: 'red' }}></ErrorRoundedIcon>
        <p> Something bad happened :(</p>
        <p>Please try again </p>
    </div>
  );
}

export default Error;
