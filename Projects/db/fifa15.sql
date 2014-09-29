CREATE TABLE Club(
	id INTEGER PRIMARY KEY ASC,
	name TEXT,
	code TEXT
);

CREATE TABLE League(
	id INTEGER PRIMARY KEY ASC,
	name TEXT,
	code TEXT
);

CREATE TABLE Nation(
	id INTEGER PRIMARY KEY ASC,
	name TEXT,
	code TEXT
);

CREATE TABLE Player(
    id INTEGER PRIMARY KEY,
    short_name TEXT,
    full_name TEXT,
    club_name TEXT,
    league_name TEXT,
    nation_name TEXT,
	club_id INTEGER,
    league_id INTEGER,
    nation_id INTEGER,
    source TEXT,
    age INTEGER,
    height INTEGER,
    weak_foot INTEGER,
    skill_moves INTEGER,
	position INTEGER,
	foot INTEGER,
	attack_workrate INTEGER,
	defensive_workrate INTEGER,
	prices_xbox INTEGER,
	prices_ps INTEGER,
	prices_pc INTEGER,
	overall_rating INTEGER,
	attribute1 INTEGER,
	attribute2 INTEGER,
	attribute3 INTEGER,
	attribute4 INTEGER,
	attribute5 INTEGER,
	attribute6 INTEGER,
	-- stats
	ball_control INTEGER,
	crossing INTEGER,
	curve INTEGER,
	dribbling INTEGER,
	finishing INTEGER,
	free_kick_accuracy INTEGER,
	HeadingAccuracy INTEGER,
	long_passing INTEGER,
	long_shots INTEGER,
	marking INTEGER,
	penalties INTEGER,
	short_passing INTEGER,
	shot_power INTEGER,
	sliding_tackle INTEGER,
	standing_tackle INTEGER,
	volleys INTEGER,
	acceleration INTEGER,
	agility INTEGER,
	balance INTEGER,
	jumping INTEGER,
	reactions INTEGER,
	sprint_speed INTEGER,
	stamina INTEGER,
	strength INTEGER,
	aggression INTEGER,
	positioning INTEGER,
	interceptions INTEGER,
	vision INTEGER,
	-- urls, datas
	image_url TEXT,
	image BLOB,
	
);