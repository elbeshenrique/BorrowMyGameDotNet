import React, { useEffect } from "react";
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import axios, { AxiosRequestConfig } from "axios";
import JsonUtils from "../Utils/JsonUtils";
import { Checkbox } from "@material-ui/core";

class Friend {
    public id: number;
    public name: string;

    constructor(id: number, name: string) {
        this.id = id;
        this.name = name;
    }
}

function Friends(): JSX.Element {
    const [Friends, setFriends] = React.useState<Friend[]>([]);

    const loadFriends = async () => {
        const config = {
            method: 'get',
            url: 'https://localhost:5001/api/v1/friend',
            headers: {
                'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImVsYmVzaEBnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTYyMTM3NzQzNywiaXNzIjoiR29yZG9uIEZyZWVtYW4iLCJhdWQiOiJyZWdpc3RlcmVkX3VzZXJzIn0.V2YWcP3kbKc8AxNDLLmeUPQsC2LKJLyDsinDO0H2WJ8'
            }
        } as AxiosRequestConfig;

        const response = await axios(config);
        const Friends = JsonUtils.plainToClassArray(Friend, response.data);
        setFriends(Friends);
    }

    useEffect(() => {
        loadFriends();
    }, []);

    return (
        <div>
            <TableContainer component={Paper}>
                <Table size="small" aria-label="a dense table">
                    <TableHead>
                        <TableRow>
                            <TableCell>Amigo</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {Friends.map((friend) => (
                            <TableRow key={friend.id.toString()}>
                                <TableCell>{friend.name}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </div>
    );
}

export default Friends;