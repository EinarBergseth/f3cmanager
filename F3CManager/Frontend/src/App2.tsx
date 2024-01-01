import { Provider } from "react-redux"
import store from "./store/store"
import Test from "./components/test"
import '@fontsource/roboto/300.css'
import '@fontsource/roboto/400.css'
import '@fontsource/roboto/500.css'
import '@fontsource/roboto/700.css'
import CssBaseline from "@mui/material/CssBaseline"
import { Container } from "@mui/material"
import MyAppBar from "./components/MyAppBar"

function App() {
    

    return (
        <Provider store={store}>
            <CssBaseline enableColorScheme  />
            <MyAppBar />
            <main>
                <Container>
                    <Test />
                </Container>
            </main>
        </Provider>
    )
}

export default App