import React, { useEffect, useState } from "react";
import HistoryCard from "./HistoryCard";

export default function History() {
	const [transactions, setTransactions] = useState([]);
	async function getHistory() {
		const response = await fetch("api/Conversions/history", { method: "GET" });
		const data = await response.json();
		console.log(data);
		setTransactions(data);
	}
	useEffect(() => {
		getHistory();
	}, []);

	return (
		<div className="history">
			{transactions === undefined ? (
				<p>No transactions yet</p>
			) : (
				transactions.map((t) => <HistoryCard transaction={t} key={t.id} />)
			)}
		</div>
	);
}
