import AppBar from "@mui/material/AppBar"
import Toolbar from "@mui/material/Toolbar"
import Typography from "@mui/material/Typography"
import MenuIcon from '@mui/icons-material/Menu'
import IconButton from "@mui/material/IconButton"
import Button from "@mui/material/Button"

const MyAppBar = () => {

    return (
        <AppBar position="relative">
            <Toolbar>
                <IconButton
                    size="large"
                    edge="start"
                    color="inherit"
                    aria-label="menu"
                    sx={{ mr: 2 }}
                    onClick={() => {console.log("Menu clicked.")}}
                >
                    <MenuIcon />
                </IconButton>
                <Typography variant="h6" color="inherit" noWrap sx={{ flexGrow: 1 }}>
                    F3C Manager
                </Typography>
                <Button color="inherit">Login</Button>
            </Toolbar>
        </AppBar>
    )
}

export default MyAppBar