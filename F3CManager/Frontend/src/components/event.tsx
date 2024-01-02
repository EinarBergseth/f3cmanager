import TextField from "@mui/material/TextField"
import { EventDTO } from "../types"
import { DateTimeField } from "@mui/x-date-pickers/DateTimeField"
import dayjs from "dayjs"
import Checkbox from "@mui/material/Checkbox"
import FormControlLabel from "@mui/material/FormControlLabel"
import { Stack } from "@mui/material"

type EventProps = {
    event: EventDTO | undefined
}

/** View for editing competition event configurations. */
const Event = ({event}: EventProps) => {

    return (
        <Stack mt={2} spacing={2}>
            <TextField 
                label="Name" 
                variant="outlined"
                value={event ? event.name : ''}
                onChange={(e) => console.log(e.target.value)}
            />
            <DateTimeField 
                label="Start" 
                value={event ? dayjs(event.startTime) : undefined}
                onChange={(e) => console.log(e)}
            />
            <DateTimeField 
                label="End" 
                value={event ? dayjs(event.endTime) : undefined}
                onChange={(e) => console.log(e)}
            />
            <FormControlLabel 
                label='Is open for registration'
                control={
                    <Checkbox
                        checked={event ? event.isOpenForRegistration : false}
                        onChange={(e) => console.log(e)}
                        inputProps={{ 'aria-label': 'controlled' }}
                    />
                } 
            />
            <DateTimeField 
                label="Registration start" 
                value={event ? dayjs(event.registrationStartTime) : undefined}
                onChange={(e) => console.log(e)}
            />
            <DateTimeField 
                label="Registration end" 
                value={event ? dayjs(event.registrationEndTime) : undefined}
                onChange={(e) => console.log(e)}
            />
        </Stack>
    )
}

export default Event