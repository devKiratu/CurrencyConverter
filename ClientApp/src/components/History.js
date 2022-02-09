import React, { useEffect, useState } from "react";

export default function History() {
	const [transactions, setTransactions] = useState([]);
	async function getHistory() {
		const response = await fetch("api/Conversions/history", { method: "GET" });
		const data = await response.json();
		// console.log(data.status);
		setTransactions(data);
	}
	useEffect(() => {
		getHistory();
	}, []);

	return (
		<div className="history">
			{transactions.status === 404 ? (
				<p>No transactions yet</p>
			) : (
				<table className="history-table">
					<thead>
						<tr>
							<th>Transaction Id</th>
							<th>From</th>
							<th>To</th>
							<th>Amount</th>
							<th>Output</th>
							<th>Transaction Date</th>
						</tr>
					</thead>
					<tbody>
						{transactions.map((t) => (
							<tr key={t.id}>
								<td>{t.id}</td>
								<td>{t.from}</td>
								<td>{t.to}</td>
								<td>{t.amount.toLocaleString("en")}</td>
								<td>{t.output.toLocaleString("en")}</td>
								<td>{new Date(t.transactedAt).toLocaleString()}</td>
							</tr>
						))}
					</tbody>
				</table>
			)}
		</div>
	);
}
