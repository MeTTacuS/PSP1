import java.time.LocalDateTime;
import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;
import java.time.Month


// INTERFACES
interface IAttendancePolicy {
    fun CheckUniqueness(distractions: Array<String>) : Boolean;
    fun AdjustIfMainActivity(isMain: Boolean, chance: Double) : Double;
    fun ChanceOfAttendance(distractions: Array<String>, isMain: Boolean, chance: Double) : Double;
    fun CalculateChanceOfAttendance(distractions: Array<String>, isMain: Boolean) : Double;
}

interface IDateCalculator {
    fun TimeSpentInUniversity(joinedDate: LocalDateTime) : String;
}

interface IRewardPolicy {
    fun CalculateRewardChance(attendancePercent: Double) : Double;
}


// IMPLEMENTS INTERFACES
class BasicRewardPolicy() : IRewardPolicy {
    override fun CalculateRewardChance(attendancePercent: Double): Double {
        if (attendancePercent > 90)
                return 98.toDouble();
            if (attendancePercent > 50)
                return 40.toDouble();
            else
                return 20.toDouble();
    }
}
class RegularAttendancePolicy : IAttendancePolicy {
    override fun CheckUniqueness(distractions: Array<String>) : Boolean {
        if (distractions.size == distractions.distinct().size) { return true; }
        else {return false;}
    }

    override fun AdjustIfMainActivity(isMain: Boolean, chance: Double) : Double {
        if (isMain)
                return chance;
            else
                return chance / 2;
    }

    override fun ChanceOfAttendance(distractions: Array<String>, isMain: Boolean, chance: Double) : Double {
        var temp = Math.abs(chance - (100 * (0.1 * distractions.size)));
        return AdjustIfMainActivity(isMain, temp);
    }

    override fun CalculateChanceOfAttendance(distractions: Array<String>, isMain: Boolean): Double {
        var chance = 100.toDouble();
        if (CheckUniqueness(distractions))
            return ChanceOfAttendance(distractions, isMain, chance);
        else
            return -1.toDouble();
    }
}
class YearsInUniversityCalculator : IDateCalculator {
    override fun TimeSpentInUniversity(joinedDate: LocalDateTime) : String {
        var year = LocalDateTime.now().year - joinedDate.year;
		if (year == 0) { return "This is his/hers first year in university"; }
		else if (year == 1) { return "This person has spent 1 year in university"; }
    	else { return "This person has spent " + year + " years in university"; }
    }
}


// Entities
open class Student() {
    private var _joinedDate: LocalDateTime = LocalDateTime.of(2015, Month.SEPTEMBER, 1, 0, 0);
    var Distractions: Array<String> = arrayOf("is lazy", "tired", "likes cartoons");
    var AttendancePercent: Double = 0.toDouble();
    var IsUniversityMainActivity: Boolean = true;

    fun SetJoinedDate(date: LocalDateTime) {
        this._joinedDate = date;
	}
    fun GetJoinedDate(): LocalDateTime {
        return this._joinedDate;
	}
}
open class Lecturer() {
    private var _joinedDate: LocalDateTime = LocalDateTime.of(2015, Month.SEPTEMBER, 1, 0, 0);
    var Distractions: Array<String>? = null;
    var AttendancePercent: Double? = null;
    var IsUniversityMainActivity: Boolean? = null;

    fun SetJoinedDate(date: LocalDateTime) {
        this._joinedDate = date;
	}
    fun GetJoinedDate(): LocalDateTime {
        return this._joinedDate;
	}
}
open class SecurityGuard() {
    private var _joinedDate: LocalDateTime = LocalDateTime.of(2014, Month.SEPTEMBER, 1, 0, 0);
    var Distractions: Array<String> = arrayOf("is lazy", "tired", "likes cartoons");
    var AttendancePercent: Double = 0.toDouble();
    var IsUniversityMainActivity: Boolean = true;

    fun SetJoinedDate(date: LocalDateTime) {
        this._joinedDate = date;
	}
    fun GetJoinedDate(): LocalDateTime {
        return this._joinedDate;
	}
    fun GetRiskOfBeingFired(): Double {
        if (Distractions!!.size == 0) { return 0.toDouble(); }
        else { return (Distractions!!.size * 8).toDouble(); }
    }
}

class RegularAttendanceBasicScholarshipStudent(attendance: IAttendancePolicy, dateCalculator: IDateCalculator, rewardPolicy: IRewardPolicy):
Student(), IAttendancePolicy by attendance, IDateCalculator by dateCalculator, IRewardPolicy by rewardPolicy;

class RegularAttendanceBasicRewardSecurityGuard(attendance: IAttendancePolicy, dateCalculator: IDateCalculator, rewardPolicy: IRewardPolicy):
SecurityGuard(), IAttendancePolicy by attendance, IDateCalculator by dateCalculator, IRewardPolicy by rewardPolicy;

fun main() {
    val distractions = arrayOf("is lazy", "tired", "likes cartoons");
    var regularStudent = RegularAttendanceBasicScholarshipStudent(RegularAttendancePolicy(), YearsInUniversityCalculator(), BasicRewardPolicy());
    regularStudent.Distractions = distractions;
    regularStudent.AttendancePercent = 90.toDouble();
    regularStudent.IsUniversityMainActivity = true;

    println("Chance of attendance is " + regularStudent.CalculateChanceOfAttendance(regularStudent.Distractions, regularStudent.IsUniversityMainActivity));

    var regularGuard = RegularAttendanceBasicRewardSecurityGuard(RegularAttendancePolicy(), YearsInUniversityCalculator(), BasicRewardPolicy())
    regularGuard.Distractions = distractions;
    regularGuard.AttendancePercent = 90.toDouble();
    regularGuard.IsUniversityMainActivity = true;
    println("===================================")
    println("Chance of attendance is " + regularGuard.CalculateChanceOfAttendance(regularGuard.Distractions, regularGuard.IsUniversityMainActivity))
    println("Chance of reward is " + regularGuard.CalculateRewardChance(regularGuard.AttendancePercent));
    println("Chance of getting fired is " + regularGuard.GetRiskOfBeingFired())
}





