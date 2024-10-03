import { Activity } from "../../app/Models/activity";
import ActivityList from "./ActivityList";

interface Props {
  activities: Activity[];
}
export default function ActivityDashboard({activities}: Props) {
  return (
    <ActivityList activities={activities} />
  );
}
